﻿using AzureDevopsStateTracker.Extensions;
using System;

namespace AzureDevopsStateTracker.Entities
{
    public class TimeByState : Entity
    {
        public string WorkItemId { get; private set; }
        public string State { get; private set; }
        public long TotalTime { get; private set; }
        public long TotalWorkedTime { get; private set; }
        public WorkItem WorkItem { get; private set; }

        private TimeByState() { }

        public TimeByState(string workItemId, string state, long totalTime, long totalWorkedTime)
        {
            WorkItemId = workItemId;
            State = state;
            TotalTime = totalTime;
            TotalWorkedTime = totalWorkedTime;

            Validate();
        }

        public void Validate()
        {
            if (WorkItemId.IsNullOrEmpty() || Convert.ToInt64(WorkItemId) <= 0)
                throw new Exception("WorkItemId is required");

            if (State.IsNullOrEmpty())
                throw new Exception("State is required");
        }
    }
}