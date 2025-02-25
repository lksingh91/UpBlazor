﻿using System;
using System.Collections.Generic;
using UpBlazor.Core.Models.Enums;

namespace UpBlazor.Core.Helpers
{
    public static class IntervalExtensions
    {
        public static TimeSpan ToTimeSpan(this Interval interval, int units) =>
            interval switch
            {
                Interval.Days => TimeSpan.FromDays(units),
                Interval.Weeks => TimeSpan.FromDays(units * 7),
                Interval.Fortnights => TimeSpan.FromDays(units * 14),
                _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
            };

        public static DateTime FindLastCycleStart(this DateTime start, Interval interval, int units, DateTime? since = null)
        {
            since ??= DateTime.Now.Date;

            var nowSubtractStart = since - start;
            if (nowSubtractStart.Value.TotalMilliseconds < 0)
            {
                return start;
            }

            var cycleStep = interval.ToTimeSpan(units);
            var currentCycle = start;
            do
            {
                currentCycle = currentCycle.Add(cycleStep);
            } while ((since - currentCycle).Value.TotalMilliseconds >= cycleStep.TotalMilliseconds);

            return currentCycle;
        }

        public static List<DateOnly> GetAllCyclesInRange(this DateTime start, DateTime rangeStart, DateTime rangeEnd, Interval interval, int units)
        {
            var startOfRange = start.FindLastCycleStart(interval, units, rangeStart);

            // Cycle hasn't started yet
            if (startOfRange > rangeEnd)
            {
                return null;
            }

            var output = new List<DateOnly>
            {
                DateOnly.FromDateTime(startOfRange)
            };
            
            // Get values until rangeEnd

            var i = 0;
            while (true)
            {
                i += units;

                var timeSpan = interval.ToTimeSpan(i);

                var potentialHit = startOfRange.Add(timeSpan);

                if (potentialHit <= rangeEnd)
                {
                    output.Add(DateOnly.FromDateTime(potentialHit));
                    continue;
                }
                
                break;
            }

            return output;
        }
    }
}