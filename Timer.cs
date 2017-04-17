﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gist { 

    public class Timer {
        public event System.Action<Timer> Elapsed;

        protected bool active;
        protected float interval;
        protected float timeOfElapsed;

        public Timer(float interval) {
            Interval = interval;
        }

        public float Interval {
            get { return interval; }
            set {
                interval = value;
                if (interval < 0f)
                    active = false;
            }
        }

        public void Start() {
            Start (interval);
        }
        public void Start(float interval) {
            active = true;
            Interval = interval;
            timeOfElapsed = Time.timeSinceLevelLoad + interval;
        }
        public void Update() {
            var currentTime = Time.timeSinceLevelLoad;
            if (active && timeOfElapsed <= currentTime) {
                active = false;
                NotifyElapsed ();
            }
        }
        public void Stop() {
            active = false;
        }

        void NotifyElapsed () {
            if (Elapsed != null)
                Elapsed (this);
        }
    }
}