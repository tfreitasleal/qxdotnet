﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qxDotNet;

namespace qxDotNet.UI.Core
{
    /// <summary>
    /// The base class of all items, which should be laid out using a layout manager
    /// {@link qx.ui.layout.Abstract}.
    /// 
    /// </summary>
    public abstract partial class LayoutItem : qxDotNet.Core.Object
    {

        private qxDotNet.AlignXEnum _alignX = (AlignXEnum)(-1);
        private qxDotNet.AlignYEnum _alignY = (AlignYEnum)(-1);
        private bool? _allowGrowX = true;
        private bool? _allowGrowY = true;
        private bool? _allowShrinkX = true;
        private bool? _allowShrinkY = true;
        private int _height = 0;
        private int _marginBottom = 0;
        private int _marginLeft = 0;
        private int _marginRight = 0;
        private int _marginTop = 0;
        private int _maxHeight = 0;
        private int _maxWidth = 0;
        private int _minHeight = 0;
        private int _minWidth = 0;
        private int _width = 0;
        private qxDotNet.UI.Core.Widget _layoutParent = null;
        private Map _layoutProperties = null;


        /// <summary>
        /// Horizontal alignment of the item in the parent layout.
        /// 
        /// Note: Item alignment is only supported by {@link LayoutItem} layouts where
        /// it would have a visual effect. Except for {@link Spacer}, which provides
        /// blank space for layouts, all classes that inherit {@link LayoutItem} support alignment.
        /// 
        /// </summary>
        public qxDotNet.AlignXEnum AlignX
        {
            get
            {
                return _alignX;
            }
            set
            {
               _alignX = value;
            }
        }

        /// <summary>
        /// Vertical alignment of the item in the parent layout.
        /// 
        /// Note: Item alignment is only supported by {@link LayoutItem} layouts where
        /// it would have a visual effect. Except for {@link Spacer}, which provides
        /// blank space for layouts, all classes that inherit {@link LayoutItem} support alignment.
        /// 
        /// </summary>
        public qxDotNet.AlignYEnum AlignY
        {
            get
            {
                return _alignY;
            }
            set
            {
               _alignY = value;
            }
        }

        /// <summary>
        /// Whether the item can grow horizontally.
        /// 
        /// </summary>
        public bool? AllowGrowX
        {
            get
            {
                return _allowGrowX;
            }
            set
            {
               _allowGrowX = value;
            }
        }

        /// <summary>
        /// Whether the item can grow vertically.
        /// 
        /// </summary>
        public bool? AllowGrowY
        {
            get
            {
                return _allowGrowY;
            }
            set
            {
               _allowGrowY = value;
            }
        }

        /// <summary>
        /// Whether the item can shrink horizontally.
        /// 
        /// </summary>
        public bool? AllowShrinkX
        {
            get
            {
                return _allowShrinkX;
            }
            set
            {
               _allowShrinkX = value;
            }
        }

        /// <summary>
        /// Whether the item can shrink vertically.
        /// 
        /// </summary>
        public bool? AllowShrinkY
        {
            get
            {
                return _allowShrinkY;
            }
            set
            {
               _allowShrinkY = value;
            }
        }

        /// <summary>
        /// The item's preferred height.
        /// 
        /// The computed height may differ from the given height due to
        /// stretching. Also take a look at the related properties
        /// {@link #minHeight} and {@link #maxHeight}.
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
               _height = value;
               OnChangeHeight();
            }
        }

        /// <summary>
        /// Margin of the widget (bottom)
        /// 
        /// </summary>
        public int MarginBottom
        {
            get
            {
                return _marginBottom;
            }
            set
            {
               _marginBottom = value;
            }
        }

        /// <summary>
        /// Margin of the widget (left)
        /// 
        /// </summary>
        public int MarginLeft
        {
            get
            {
                return _marginLeft;
            }
            set
            {
               _marginLeft = value;
            }
        }

        /// <summary>
        /// Margin of the widget (right)
        /// 
        /// </summary>
        public int MarginRight
        {
            get
            {
                return _marginRight;
            }
            set
            {
               _marginRight = value;
            }
        }

        /// <summary>
        /// Margin of the widget (top)
        /// 
        /// </summary>
        public int MarginTop
        {
            get
            {
                return _marginTop;
            }
            set
            {
               _marginTop = value;
            }
        }

        /// <summary>
        /// The user provided maximum height.
        /// 
        /// Also take a look at the related properties {@link #height} and {@link #minHeight}.
        /// 
        /// </summary>
        public int MaxHeight
        {
            get
            {
                return _maxHeight;
            }
            set
            {
               _maxHeight = value;
            }
        }

        /// <summary>
        /// The user provided maximal width.
        /// 
        /// Also take a look at the related properties {@link #width} and {@link #minWidth}.
        /// 
        /// </summary>
        public int MaxWidth
        {
            get
            {
                return _maxWidth;
            }
            set
            {
               _maxWidth = value;
            }
        }

        /// <summary>
        /// The user provided minimal height.
        /// 
        /// Also take a look at the related properties {@link #height} and {@link #maxHeight}.
        /// 
        /// </summary>
        public int MinHeight
        {
            get
            {
                return _minHeight;
            }
            set
            {
               _minHeight = value;
            }
        }

        /// <summary>
        /// The user provided minimal width.
        /// 
        /// Also take a look at the related properties {@link #width} and {@link #maxWidth}.
        /// 
        /// </summary>
        public int MinWidth
        {
            get
            {
                return _minWidth;
            }
            set
            {
               _minWidth = value;
            }
        }

        /// <summary>
        /// The LayoutItem's preferred width.
        /// 
        /// The computed width may differ from the given width due to
        /// stretching. Also take a look at the related properties
        /// {@link #minWidth} and {@link #maxWidth}.
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
               _width = value;
               OnChangeWidth();
            }
        }

        /// <summary>
        /// Get the items parent. Even if the item has been added to a
        /// layout, the parent is always a child of the containing item. The parent
        /// item may be null.
        /// 
        /// Set the parent
        /// 
        /// </summary>
        public qxDotNet.UI.Core.Widget LayoutParent
        {
            get
            {
                return _layoutParent;
            }
            set
            {
               _layoutParent = value;
            }
        }

        /// <summary>
        /// Returns currently stored layout properties
        /// 
        /// Stores the given layout properties
        /// 
        /// </summary>
        public Map LayoutProperties
        {
            get
            {
                return _layoutProperties;
            }
            set
            {
               _layoutProperties = value;
            }
        }


        /// <summary>
        /// Returns Qooxdoo type name for this type
        /// </summary>
        /// <returns>string</returns>
        protected internal override string GetTypeName()
        {
            return "qx.ui.core.LayoutItem";
        }

        /// <summary>
        /// Generates client code
        /// </summary>
        /// <param name="state">Serialized property values</param>
        internal override void Render(qxDotNet.Core.Object.PropertyBag state)
        {
            base.Render(state);
            state.SetPropertyValue("alignX", _alignX, (AlignXEnum)(-1));
            state.SetPropertyValue("alignY", _alignY, (AlignYEnum)(-1));
            state.SetPropertyValue("allowGrowX", _allowGrowX, true);
            state.SetPropertyValue("allowGrowY", _allowGrowY, true);
            state.SetPropertyValue("allowShrinkX", _allowShrinkX, true);
            state.SetPropertyValue("allowShrinkY", _allowShrinkY, true);
            state.SetPropertyValue("height", _height, 0);
            state.SetPropertyValue("marginBottom", _marginBottom, 0);
            state.SetPropertyValue("marginLeft", _marginLeft, 0);
            state.SetPropertyValue("marginRight", _marginRight, 0);
            state.SetPropertyValue("marginTop", _marginTop, 0);
            state.SetPropertyValue("maxHeight", _maxHeight, 0);
            state.SetPropertyValue("maxWidth", _maxWidth, 0);
            state.SetPropertyValue("minHeight", _minHeight, 0);
            state.SetPropertyValue("minWidth", _minWidth, 0);
            state.SetPropertyValue("width", _width, 0);
            state.SetPropertyValue("layoutParent", _layoutParent, null);
            state.SetPropertyValue("layoutProperties", _layoutProperties, null);


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
        /// Raises event 'ChangeHeight'
        /// </summary>
        protected virtual void OnChangeHeight()
        {
            if (ChangeHeight != null)
            {
                ChangeHeight.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #height}.
        /// </summary>
        public event EventHandler ChangeHeight;

        /// <summary>
        /// Raises event 'ChangeWidth'
        /// </summary>
        protected virtual void OnChangeWidth()
        {
            if (ChangeWidth != null)
            {
                ChangeWidth.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fired on change of the property {@link #width}.
        /// </summary>
        public event EventHandler ChangeWidth;

    }
}
