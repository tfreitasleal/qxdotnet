﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qxDotNet;

namespace qxDotNet.UI.Layout
{
    /// <summary>
    /// A vertical box layout.
    /// 
    /// The vertical box layout lays out widgets in a vertical column, from top
    /// to bottom.
    /// 
    /// Features
    /// 
    /// 
    /// Minimum and maximum dimensions
    /// Prioritized growing/shrinking (flex)
    /// Margins (with vertical collapsing)
    /// Auto sizing (ignoring percent values)
    /// Percent heights (not relevant for size hint)
    /// Alignment (child property {@link qx.ui.core.LayoutItem#alignY} is ignored)
    /// Vertical spacing (collapsed with margins)
    /// Reversed children layout (from last to first)
    /// Horizontal children stretching (respecting size hints)
    /// 
    /// 
    /// Item Properties
    /// 
    /// 
    /// flex (Integer): The flexibility of a layout item determines how the container
    ///  distributes remaining empty space among its children. If items are made
    ///  flexible, they can grow or shrink accordingly. Their relative flex values
    ///  determine how the items are being resized, i.e. the larger the flex ratio
    ///  of two items, the larger the resizing of the first item compared to the
    ///  second.
    /// 
    /// If there is only one flex item in a layout container, its actual flex
    ///  value is not relevant. To disallow items to become flexible, set the
    ///  flex value to zero.
    /// 
    /// height (String): Allows to define a percent
    ///  height for the item. The height in percent, if specified, is used instead
    ///  of the height defined by the size hint. The minimum and maximum height still
    ///  takes care of the element's limits. It has no influence on the layout's
    ///  size hint. Percent values are mostly useful for widgets which are sized by
    ///  the outer hierarchy.
    /// 
    /// 
    /// 
    /// Example
    /// 
    /// Here is a little example of how to use the vertical box layout.
    /// 
    /// 
    /// var layout = new qx.ui.layout.VBox();
    /// layout.setSpacing(4); // apply spacing
    /// 
    /// var container = new qx.ui.container.Composite(layout);
    /// 
    /// container.add(new qx.ui.core.Widget());
    /// container.add(new qx.ui.core.Widget());
    /// container.add(new qx.ui.core.Widget());
    /// 
    /// 
    /// External Documentation
    /// 
    /// See extended documentation
    /// and links to demos for this layout.
    /// 
    /// </summary>
    public partial class VBox : qxDotNet.UI.Layout.Abstract
    {

        private qxDotNet.AlignXEnum _alignX = AlignXEnum.left;
        private qxDotNet.AlignYEnum _alignY = AlignYEnum.top;
        private bool? _reversed = false;
        private string _separator = null;
        private int _spacing = 0;


        /// <summary>
        /// Horizontal alignment of each child. Can be overridden through
        /// {@link qx.ui.core.LayoutItem#alignX}.
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
        /// Vertical alignment of the whole children block. The vertical
        /// alignment of the child is completely ignored in VBoxes (
        /// {@link qx.ui.core.LayoutItem#alignY}).
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
        /// Whether the actual children list should be laid out in reversed order.
        /// 
        /// </summary>
        public bool? Reversed
        {
            get
            {
                return _reversed;
            }
            set
            {
               _reversed = value;
            }
        }

        /// <summary>
        /// Separator lines to use between the objects
        /// 
        /// </summary>
        public string Separator
        {
            get
            {
                return _separator;
            }
            set
            {
               _separator = value;
            }
        }

        /// <summary>
        /// Vertical spacing between two children
        /// 
        /// </summary>
        public int Spacing
        {
            get
            {
                return _spacing;
            }
            set
            {
               _spacing = value;
            }
        }


        /// <summary>
        /// Returns Qooxdoo type name for this type
        /// </summary>
        /// <returns>string</returns>
        protected internal override string GetTypeName()
        {
            return "qx.ui.layout.VBox";
        }

        /// <summary>
        /// Generates client code
        /// </summary>
        /// <param name="state">Serialized property values</param>
        internal override void Render(qxDotNet.Core.Object.PropertyBag state)
        {
            base.Render(state);
            state.SetPropertyValue("alignX", _alignX, AlignXEnum.left);
            state.SetPropertyValue("alignY", _alignY, AlignYEnum.top);
            state.SetPropertyValue("reversed", _reversed, false);
            state.SetPropertyValue("separator", _separator, null);
            state.SetPropertyValue("spacing", _spacing, 0);


        }

        /// <summary>
        /// Dispatches client events
        /// </summary>
        /// <param name="eventName">Client event name</param>
        internal override void InvokeEvent(string eventName)
        {
            base.InvokeEvent(eventName);
        }

    }
}
