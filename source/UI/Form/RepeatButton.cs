﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qxDotNet;

namespace qxDotNet.UI.Form
{
    /// <summary>
    /// The RepeatButton is a special button, which fires repeatedly {@link #execute}
    /// events, while a button is pressed on the button. The initial delay
    /// and the interval time can be set using the properties {@link #firstInterval}
    /// and {@link #interval}. The {@link #execute} events will be fired in a shorter
    /// amount of time if a button is hold, until the min {@link #minTimer}
    /// is reached. The {@link #timerDecrease} property sets the amount of milliseconds
    /// which will decreased after every firing.
    /// 
    /// 
    ///  var button = new qx.ui.form.RepeatButton("Hello World");
    /// 
    ///  button.addListener("execute", function(e) {
    ///  alert("Button is executed");
    ///  }, this);
    /// 
    ///  this.getRoot.add(button);
    /// 
    /// 
    /// This example creates a button with the label "Hello World" and attaches an
    /// event listener to the {@link #execute} event.
    /// 
    /// External Documentation
    /// 
    /// 
    /// Documentation of this widget in the qooxdoo manual.
    /// </summary>
    public partial class RepeatButton : qxDotNet.UI.Form.Button
    {

        private int _firstInterval = 500;
        private int _interval = 100;
        private int _minTimer = 20;
        private int _timerDecrease = 2;


        /// <summary>
        /// Interval used for the first run of the timer. Usually a greater value
        /// than the "interval" property value to a little delayed reaction at the first
        /// time.
        /// 
        /// </summary>
        public int FirstInterval
        {
            get
            {
                return _firstInterval;
            }
            set
            {
               _firstInterval = value;
            }
        }

        /// <summary>
        /// Interval used after the first run of the timer. Usually a smaller value
        /// than the "firstInterval" property value to get a faster reaction.
        /// 
        /// </summary>
        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
               _interval = value;
            }
        }

        /// <summary>
        /// This configures the minimum value for the timer interval.
        /// 
        /// </summary>
        public int MinTimer
        {
            get
            {
                return _minTimer;
            }
            set
            {
               _minTimer = value;
            }
        }

        /// <summary>
        /// Decrease of the timer on each interval (for the next interval) until minTimer reached.
        /// 
        /// </summary>
        public int TimerDecrease
        {
            get
            {
                return _timerDecrease;
            }
            set
            {
               _timerDecrease = value;
            }
        }


        /// <summary>
        /// Returns Qooxdoo type name for this type
        /// </summary>
        /// <returns>string</returns>
        protected internal override string GetTypeName()
        {
            return "qx.ui.form.RepeatButton";
        }

        /// <summary>
        /// Generates client code
        /// </summary>
        /// <param name="state">Serialized property values</param>
        internal override void Render(qxDotNet.Core.Object.PropertyBag state)
        {
            base.Render(state);
            state.SetPropertyValue("firstInterval", _firstInterval, 500);
            state.SetPropertyValue("interval", _interval, 100);
            state.SetPropertyValue("minTimer", _minTimer, 20);
            state.SetPropertyValue("timerDecrease", _timerDecrease, 2);

            if (Execute != null)
            {
                state.SetEvent("execute", true);
            }
            if (Press != null)
            {
                state.SetEvent("press", false);
            }
            if (Release != null)
            {
                state.SetEvent("release", false);
            }

        }

        /// <summary>
        /// Dispatches client events
        /// </summary>
        /// <param name="eventName">Client event name</param>
        internal override void InvokeEvent(string eventName)
        {
            base.InvokeEvent(eventName);
            if (eventName == "execute")
            {
                OnExecute();
            }
            if (eventName == "press")
            {
                OnPress();
            }
            if (eventName == "release")
            {
                OnRelease();
            }
        }

        /// <summary>
        /// Raises event 'Execute'
        /// </summary>
        protected virtual void OnExecute()
        {
            if (Execute != null)
            {
                Execute.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// This event gets dispatched with every interval. The timer gets executed
        /// as long as the user holds down a button.
        /// 
        /// </summary>
        public event EventHandler Execute;

        /// <summary>
        /// Raises event 'Press'
        /// </summary>
        protected virtual void OnPress()
        {
            if (Press != null)
            {
                Press.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// This event gets dispatched when the button is pressed.
        /// 
        /// </summary>
        public event EventHandler Press;

        /// <summary>
        /// Raises event 'Release'
        /// </summary>
        protected virtual void OnRelease()
        {
            if (Release != null)
            {
                Release.Invoke(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// This event gets dispatched when the button is released.
        /// 
        /// </summary>
        public event EventHandler Release;

    }
}
