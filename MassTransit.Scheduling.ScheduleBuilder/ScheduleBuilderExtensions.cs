using System;

namespace MassTransit.Scheduling.ScheduleBuilder
{
    public static class ScheduleBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="cron"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithCronExpression(this ScheduleBuilder scheduleBuilder, string cron)
        {
            scheduleBuilder.SetCronExpression(cron);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithIntervalInSeconds(this ScheduleBuilder scheduleBuilder, int interval)
        {
            scheduleBuilder.SetCronExpression($"0/{interval} 0 0 ? * * *");
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithIntervalInMinutes(this ScheduleBuilder scheduleBuilder, int interval)
        {
            scheduleBuilder.SetCronExpression($"0 0/{interval} 0 ? * * *");
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithDescription(this ScheduleBuilder scheduleBuilder, string description)
        {
            scheduleBuilder.SetDescription(description);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static ScheduleBuilder StartAt(this ScheduleBuilder scheduleBuilder, DateTimeOffset startTime)
        {
            scheduleBuilder.SetStartTime(startTime);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static ScheduleBuilder EndAt(this ScheduleBuilder scheduleBuilder, DateTimeOffset endTime)
        {
            scheduleBuilder.SetEndTime(endTime);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithTimes(this ScheduleBuilder scheduleBuilder, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            scheduleBuilder.SetStartTime(startTime);
            scheduleBuilder.SetEndTime(endTime);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="timeZoneId"></param>
        /// <returns></returns>
        public static ScheduleBuilder InTimeZone(this ScheduleBuilder scheduleBuilder, string timeZoneId)
        {
            scheduleBuilder.SetTimeZoneId(timeZoneId);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="scheduleGroup"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithScheduleGroup(this ScheduleBuilder scheduleBuilder, string scheduleGroup)
        {
            scheduleBuilder.SetScheduleGroup(scheduleGroup);
            return scheduleBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleBuilder"></param>
        /// <param name="misfirePolicy"></param>
        /// <returns></returns>
        public static ScheduleBuilder WithMisfirePolicy(this ScheduleBuilder scheduleBuilder, MissedEventPolicy misfirePolicy)
        {
            scheduleBuilder.SetMisfirePolicy(misfirePolicy);
            return scheduleBuilder;
        }
    }
}
