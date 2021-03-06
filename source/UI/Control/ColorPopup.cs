﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qxDotNet;

namespace qxDotNet.UI.Control
{
    /// <summary>
    /// A popup which contains palettes of colors and the possibility to open the
    /// Colorselector to choose a color.
    /// 
    /// </summary>
    public partial class ColorPopup : qxDotNet.UI.Popup.Popup, qxDotNet.UI.Form.IColorForm
    {

        private decimal _blue = 0m;
        private decimal _green = 0m;
        private decimal _red = 0m;


        /// <summary>
        /// The numeric blue value of the selected color.
        /// 
        /// </summary>
        public decimal Blue
        {
            get
            {
                return _blue;
            }
            set
            {
               _blue = value;
               OnChangeBlue();
            }
        }

        /// <summary>
        /// The numeric green value of the selected color.
        /// 
        /// </summary>
        public decimal Green
        {
            get
            {
                return _green;
            }
            set
            {
               _green = value;
               OnChangeGreen();
            }
        }

        /// <summary>
        /// The numeric red value of the selected color.
        /// 
        /// </summary>
        public decimal Red
        {
            get
            {
                return _red;
            }
            set
            {
               _red = value;
               OnChangeRed();
            }
        }


        /// <summary>
        /// Returns Qooxdoo type name for this type
        /// </summary>
        /// <returns>string</returns>
        protected internal override string GetTypeName()
        {
            return "qx.ui.control.ColorPopup";
        }

        /// <summary>
        /// Generates client code
        /// </summary>
        /// <param name="state">Serialized property values</param>
        internal override void Render(qxDotNet.Core.Object.PropertyBag state)
        {
            base.Render(state);
            state.SetPropertyValue("blue", _blue, 0m);
            state.SetPropertyValue("green", _green, 0m);
            state.SetPropertyValue("red", _red, 0m);

            state.SetPropertyValue("value", _value, null);

            if (ChangeValue != null)
            {
                state.SetEvent("changeValue", true, "value");
            }
            else
            {
                state.SetEvent("changeValue", false, "value");
            }

        }

        /// <summary>
        /// Dispatches client events
        /// </summary>
        /// <param name="eventName">Client event name</param>
        internal override void InvokeEvent(string eventName)
        {
            base.InvokeEvent(eventName);
        }

        /// <summary>
        /// Raises event 'ChangeBlue'
        /// </summary>
        protected virtual void OnChangeBlue()
        {
            if (ChangeBlue != null)
            {
                ChangeBlue.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #blue}.
        /// </summary>
        public event EventHandler ChangeBlue;

        /// <summary>
        /// Raises event 'ChangeGreen'
        /// </summary>
        protected virtual void OnChangeGreen()
        {
            if (ChangeGreen != null)
            {
                ChangeGreen.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #green}.
        /// </summary>
        public event EventHandler ChangeGreen;

        /// <summary>
        /// Raises event 'ChangeRed'
        /// </summary>
        protected virtual void OnChangeRed()
        {
            if (ChangeRed != null)
            {
                ChangeRed.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #red}.
        /// </summary>
        public event EventHandler ChangeRed;

        /// <summary>
        /// Raises event 'ChangeValue'
        /// </summary>
        protected virtual void OnChangeValue()
        {
            if (ChangeValue != null)
            {
                ChangeValue.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #value}.
        /// </summary>
        public event EventHandler ChangeValue;

    }
}
