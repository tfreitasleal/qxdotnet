﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qxDotNet.Core
{
    public abstract class Object
    {
        private long _clientId = 0;
        private bool _created = false;
        private PropertyBag _state;

        public Object()
        {
            _state = new PropertyBag(this);
        }

        private static Dictionary<string, Dictionary<string, System.Reflection.PropertyInfo>> _propertyCache 
            = new Dictionary<string, Dictionary<string, System.Reflection.PropertyInfo>>();

        private static void checkPropertyCache(Type type)
        {
            var name = type.FullName;
            lock (_propertyCache)
            {
                if (!_propertyCache.ContainsKey(name))
                {
                    var rec = new Dictionary<string, System.Reflection.PropertyInfo>();
                    foreach (var p in type.GetProperties())
                    {
                        if (p.GetIndexParameters().Length == 0)
                        {
                            var propName = p.Name.ToLower();
                            var attr = p.GetCustomAttributes(typeof (Common.PropertyNameAttribute), false);
                            if (attr != null)
                            {
                                if (attr.Length > 0)
                                {
                                    var ca = (attr[0] as Common.PropertyNameAttribute);
                                    if (ca.Name != null && ca.Name != "")
                                    {
                                        propName = ca.Name.ToLower();
                                    }
                                }
                            }
                            rec.Add(propName, p);
                        }
                    }
                    _propertyCache.Add(name, rec);
                }
            }
        }

        internal void SetPropertyValue(string name, string value)
        {
            name = name.ToLower();
            var t = this.GetType();
            checkPropertyCache(t);
            System.Reflection.PropertyInfo p = null;
            lock (_propertyCache)
            {
                if (_propertyCache.ContainsKey(t.FullName))
                {
                    var rec = _propertyCache[t.FullName];
                    if (rec.ContainsKey(name))
                    {
                        p = rec[name];
                    }
                }
            }
            if (p != null)
            {
                p.SetValue(this, ConvertToType(p.PropertyType, value), null);
            }
        }

        internal long clientId
        {
            get
            {
                if (_clientId == 0)
                {
                    _clientId = Common.ApplicationState.Instance.RequestControlId();
                }
                return _clientId;
            }
        }

        public abstract string GetTypeName();

        internal virtual void Render(PropertyBag state)
        {
            
        }

        internal virtual void InvokeEvent(string eventName)
        {

        }
        
        internal virtual System.Collections.IEnumerable GetChildren(bool isNewOnly)
        {
            return null;
        }

        internal virtual System.Collections.IEnumerable GetRemovedChildren()
        {
            return null;
        }

        internal virtual string GetAddObjectReference(Object obj)
        {
            return null;
        }

        internal virtual string GetRemoveObjectReference(Object obj)
        {
            return null;
        }

        internal PropertyBag GetState()
        {
            return _state;
        }
        
        internal bool IsCreated
        {
            get
            {
                return _created;
            }
        }

        internal virtual bool DisallowCreation
        {
            get
            {
                return false;
            }
        }

        internal virtual void Commit()
        {
            _created = true;
            _state.Commit();
        }

        internal virtual string GetReference()
        {
            return "ctr[" + clientId + "]";
        }

        internal virtual string GetGetPropertyAccessor(string name, bool isRef)
        {
            if (char.IsLetter(name[0]))
            {
                var fl = char.ToUpper(name[0]);
                name = "get" + fl + name.Substring(1) + "()";
            }
            else
            {
                name = "get" + name + "()";
            }
            if (isRef)
            {
                name += "._id_";
            }
            return name;
        }

        internal virtual string GetSetPropertyValueExpression(string name, object value)
        {
            return GetReference() + "." + GetSetPropertyAccessor(name) + "(" + GetClientValue(value) + ");\n";
        }

        internal virtual string GetSetPropertyAccessor(string name)
        {
            if (char.IsLetter(name[0]))
            {
                var fl = char.ToUpper(name[0]);
                name = "set" + fl + name.Substring(1);
            }
            else
            {
                name = "set" + name;
            }
            return name;
        }

        internal virtual string GetClientValue(object value)
        {
            if (value == null)
            {
                return "null";
            }
            else if (value is string)
            {
                return "\"" + (value as string).EscapeToJS() + "\"";
            }
            else if (value is Core.Object)
            {
                return (value as Core.Object).GetReference();
            }
            else if (value is Enum)
            {
                return "\"" + Enum.GetName(value.GetType(), value) + "\"";
            }
            else
            {
                return value.ToString().EscapeToJS();
            }
        }

        internal virtual object ConvertToType(Type type, string value)
        {
            if (type.IsSubclassOf(typeof(Core.Object)))
            {
                long id = 0;
                if (long.TryParse(value, out id))
                {
                    return Common.ApplicationState.Instance.GetControlByID(id);
                }
                else
                {
                    return null;
                }
            }
            else if (type.IsSubclassOf(typeof(Enum)))
            {
                return Enum.Parse(type, value, false);
            }
            else return value;
        }

        internal class PropertyBag
        {

            private Dictionary<string, object> _newPropertyValues;
            private Dictionary<string, object> _committedPropertyValues;
            private Dictionary<string, EventInfo> _newEvents;
            private Dictionary<string, EventInfo> _committedEvents;
            private Object _owner;

            public PropertyBag(Object AOwner)
            {
                _owner = AOwner;
                _newPropertyValues = new Dictionary<string, object>();
                _committedPropertyValues = new Dictionary<string, object>();
                _newEvents = new Dictionary<string, EventInfo>();
                _committedEvents = new Dictionary<string, EventInfo>();
            }

            public void Commit()
            {
                foreach (var item in _newEvents)
                {
                    _committedEvents[item.Key] = item.Value;
                }
                foreach (var item in _newPropertyValues)
                {
                    _committedPropertyValues[item.Key] = item.Value;
                }
                _newPropertyValues.Clear();
                _newEvents.Clear();
            }

            public Dictionary<string, object> GetAllProperies()
            {
                var result = new Dictionary<string, object>();
                foreach (var item in _committedPropertyValues)
                {
                    result[item.Key] = item.Value;
                }
                foreach (var item in _newPropertyValues)
                {
                    result[item.Key] = item.Value;
                }
                return result;
            }

            public Dictionary<string, object> GetNewProperties()
            {
                return _newPropertyValues;
            }

            public List<EventInfo> GetAllEvents()
            {
                var result = new Dictionary<string, EventInfo>();
                foreach (var item in _committedEvents)
                {
                    result[item.Key] = item.Value;
                }
                foreach (var item in _newEvents)
                {
                    result[item.Key] = item.Value;
                }
                return result.Values.ToList();
            }

            public List<EventInfo> GetNewEvents()
            {
                return _newEvents.Values.ToList();
            }

            public void SetPropertyValue(string propertyName, object value, object defaultValue)
            {
                if (_committedPropertyValues.ContainsKey(propertyName))
                {
                    if (_committedPropertyValues[propertyName] == value)
                    {
                        return;
                    }
                    if (_owner.IsCreated || value != defaultValue)
                    {
                        _newPropertyValues[propertyName] = value;
                    }
                }
                else
                {
                    var isEquals = false;
                    if (value == null && defaultValue == null)
                        isEquals = true;
                    else
                        if (value == defaultValue)
                            isEquals = true;
                        else
                            if (defaultValue != null)
                                if (defaultValue.Equals(value))
                                    isEquals = true;
                    if (!isEquals)
                    {
                        _newPropertyValues[propertyName] = value;
                    }
                }
            }

            public void SetEvent(string eventName, bool callServer, params string[] modifiedProperty)
            {
                SetEvent(eventName, callServer, modifiedProperty.ToList());
            }

            public void SetEvent(string eventName, bool callServer, List<string> modifiedProperties)
            {
                var ev = new EventInfo() { name = eventName, modifiedProperies = modifiedProperties, callServer = callServer };
                if (modifiedProperties != null)
                {
                    var t = _owner.GetType();
                    checkPropertyCache(t);
                    lock (_propertyCache)
                    {
                        if (_propertyCache.ContainsKey(t.FullName))
                        {
                            var rec = _propertyCache[t.FullName];
                            foreach (var item in modifiedProperties)
                            {
                                if (rec.ContainsKey(item))
                                {
                                    var p = rec[item];
                                    if (p.PropertyType.IsSubclassOf(typeof(qxDotNet.Core.Object)))
                                    {
                                        ev.referencedProperies.Add(item);
                                    }
                                }
                            }
                        }
                    }
                }
                SetEvent(ev);
            }

            public void SetEvent(string eventName, bool callServer)
            {
                var ev = new EventInfo() { name = eventName, callServer = callServer };
                SetEvent(ev);
            }

            public void SetEvent(EventInfo ev)
            {
                if (_newEvents.ContainsKey(ev.name) || !_committedEvents.ContainsKey(ev.name))
                {
                    _newEvents[ev.name] = ev;
                }
            }

        }

        public class EventInfo
        {

            public EventInfo()
            {
                modifiedProperies = new List<string>();
                referencedProperies = new List<string>();
            }

            public string name { get; set; }
            public List<string> modifiedProperies { get; set; }
            public bool callServer { get; set; }
            public List<string> referencedProperies { get; set; }

        }

    }
}