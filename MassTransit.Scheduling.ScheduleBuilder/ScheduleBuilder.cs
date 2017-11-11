using System;

namespace MassTransit.Scheduling.ScheduleBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class ScheduleBuilder
    {
        private readonly InternalSchedule _schedule;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ScheduleBuilder Create(string description = null)
        {
            return new ScheduleBuilder(description);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public ScheduleBuilder(string description = null)
        {
            _schedule = new InternalSchedule(description);
        }

        private class InternalSchedule : RecurringSchedule
        {
            public string TimeZoneId { get; internal set; }
            public DateTimeOffset StartTime { get; internal set; }
            public DateTimeOffset? EndTime { get; internal set; }
            public string ScheduleId { get; internal set; }
            public string ScheduleGroup { get; internal set; }
            public string CronExpression { get; internal set; }
            public string Description { get; internal set; }
            public MissedEventPolicy MisfirePolicy { get; internal set; }

            public InternalSchedule()
            {
            }

            public InternalSchedule(string description)
            {
                Description = description;
            }
        }

        internal void SetCronExpression(string cron) => _schedule.CronExpression = cron;

        internal void SetScheduleId(string scheduleId) => _schedule.ScheduleId = scheduleId;

        internal void SetScheduleGroup(string scheduleGroup) => _schedule.ScheduleGroup = scheduleGroup;

        internal void SetDescription(string description) => _schedule.Description = description;

        internal void SetMisfirePolicy(MissedEventPolicy misfirePolicy) => _schedule.MisfirePolicy = misfirePolicy;

        internal void SetStartTime(DateTimeOffset startTime) => _schedule.StartTime = startTime;

        internal void SetEndTime(DateTimeOffset endTime) => _schedule.EndTime = endTime;

        internal void SetTimeZoneId(string timeZoneId) => _schedule.TimeZoneId = timeZoneId;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Build<T>() where T : class, RecurringSchedule => _schedule as T;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RecurringSchedule Build() => _schedule;
    }
}
