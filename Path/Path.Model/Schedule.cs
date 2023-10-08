using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Schedule
{
    public int IdSchedule { get; set; }

    public int? IdService { get; set; }

    public DateTime? StartDay { get; set; }

    public DateTime? StartBreak { get; set; }

    public DateTime? Endbreak { get; set; }

    public DateTime? EndDay { get; set; }

    public virtual Service? IdServiceNavigation { get; set; }
}
