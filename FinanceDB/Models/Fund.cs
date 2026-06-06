using System;
using System.Collections.Generic;

namespace FinanceDB.Models;

public partial class Fund
{
    public required string Fund1 { get; set; }

    public double? Share { get; set; }

    public byte? AddShares { get; set; }

    public double? PerShare { get; set; }

    public double? DistYield { get; set; }

    public byte? AddTotal { get; set; }

    public double? Total { get; set; }

    public double? YrDividend { get; set; }

    public double? PerDiv { get; set; }

    public double? ExpRatio { get; set; }

    public byte? AddYrDiv { get; set; }

    public double? TotYrDiv { get; set; }

    public double? TRatio { get; set; }

    public double? Ratio { get; set; }

    public double? TRatDiff { get; set; }

    public string? DivFreq { get; set; } = null!;

    public string? Desc { get; set; } = null!;
}
