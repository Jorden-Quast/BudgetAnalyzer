﻿using System.Text.Json.Serialization;

namespace BudgetAnalyzer.Shared.Data;

/// <summary>
/// Attempts to make working with percentages similar to how it would be done if writing on math on paper.
/// Percentages are whole numbers (50% = 50) until you do math with them
/// </summary>
public readonly struct Percentage
{
    [JsonInclude]
    private decimal FractionalValue { get; init; }

    /// <summary> Creates a new percentage instance. Value should be the numerical percentage ie 10% = "10" </summary>
    public Percentage(decimal percentValue) => FractionalValue = (percentValue / 100);
    public static implicit operator Percentage(decimal value) => new(value);
    public static explicit operator decimal(Percentage value) => value.FractionalValue * 100;

    /// <summary> Converts the percentage to a round-trip string, leaving off the '%' character.</summary>
    public override string ToString() => (FractionalValue * 100).ToString("R");

    /// <summary> Converts the percentage to a string following a specified format, leaving off the '%' character</summary>
    public string ToString(string format) => (FractionalValue * 100).ToString(format);
    public decimal PercentOf(decimal value) => FractionalValue * value;

    // Percentage-Number operations
    public static decimal operator +(Percentage left, decimal right) => (1 + left.FractionalValue) * right;
    public static decimal operator +(decimal left, Percentage right) => left * (1 + right.FractionalValue);

    public static decimal operator -(decimal left, Percentage right) => left * (1 - right.FractionalValue);

    // Percentage-Percentage operations
    public static Percentage operator +(Percentage left, Percentage right) => new((left.FractionalValue + right.FractionalValue) * 100);
    public static Percentage operator -(Percentage left, Percentage right) => new((left.FractionalValue - right.FractionalValue) * 100);

}
