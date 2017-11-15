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
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public static ScheduleBuilder Create(string scheduleId = null)
        {
            return new ScheduleBuilder(scheduleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleId"></param>
        public ScheduleBuilder(string scheduleId = null)
        {
            _schedule = new InternalSchedule(scheduleId);
        }

        private class InternalSchedule : RecurringSchedule
        {
            public string TimeZoneId { get; internal set; }
            public DateTimeOffset StartTime { get; internal set; }
            public DateTimeOffset? EndTime { get; internal set; }
            public string ScheduleId { get; }
            public string ScheduleGroup { get; internal set; }
            public string CronExpression { get; internal set; }
            public string Description { get; internal set; }
            public MissedEventPolicy MisfirePolicy { get; internal set; }

            public InternalSchedule(string scheduleId)
            {
                ScheduleId = scheduleId;
            }
        }

        internal void SetCronExpression(string cron) => _schedule.CronExpression = cron;

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
