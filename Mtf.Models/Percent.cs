using System;

namespace Mtf.Models
{
    public struct Percent : IEquatable<Percent>
    {
        public Percent(byte value) : this(value, true)
        { }

        public Percent(byte value, bool throwException)
            : this()
        {
            if (throwException && (value > 100))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Percent value cannot be over 100");
            }

            Value = Math.Min(value, (byte)100);
        }

        public byte Value { get; private set; }

        public static implicit operator Percent(byte value)
        {
            return ToPercent(value);
        }

        public static Percent ToPercent(byte value)
        {
            return new Percent(value);
        }

        public static implicit operator Percent(int value)
        {
            return new Percent((byte)value);
        }

        public static implicit operator byte(Percent myself)
        {
            return ToByte(myself.Value);
        }

        public static bool operator ==(Percent left, Percent right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percent left, Percent right)
        {
            return !(left == right);
        }

        public static byte ToByte(Percent myself)
        {
            return myself.Value;
        }

        public override string ToString()
        {
            return String.Concat(Value, '%');
        }

        public float ToProbabitity()
        {
            return (float)Value / 100;
        }

        public override bool Equals(object obj)
        {
            return obj is Percent percent && Equals(percent);
        }

        public bool Equals(Percent other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value % 10;
        }
    }
}
