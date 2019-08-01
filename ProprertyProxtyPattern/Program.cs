using System;
using System.Collections.Generic;
using static System.Console;

namespace ProprertyProxtyPattern
{
    class Program
    {
        public class Property<T> where T : new()
        {
            private T value;

            public T Value
            {
                get => value;
                set
                {
                    if (Equals(this.value, value)) return;
                    WriteLine($"Assigning value to {value}");
                    this.value = value;
                }
            }
            public Property() : this(default(T))
            {

            }

            public Property(T value)
            {
                this.value = value;
            }

            public static implicit operator T(Property<T> property)
            {
                return property.value; // int n = p_int
            }

            public static implicit operator Property<T>(T value)
            {
                return new Property<T>(value); // Property<T> p = 123;
            }

            public bool Equals(Property<T> other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return EqualityComparer<T>.Default.Equals(value, other.value);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Property<T>)obj);
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            public static bool operator ==(Property<T> left, Property<T> right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Property<T> left, Property<T> right)
            {
                return !Equals(left, right);
            }
        }

        public class Creature
        {
            private Property<int> agility = new Property<int>(20);

            public int Agility {
                get => agility.Value;
                set => agility.Value = value;
            }
        }

        public class SampleImplicit
        {
            private string text;
            public string Text => text;

            public SampleImplicit() : this("default")
            {

            }

            public SampleImplicit(string text)
            {
                this.text = text;
            }

            public static implicit operator SampleImplicit(string text)
            {
                return new SampleImplicit(text);
            }

            public override string ToString()
            {
                return text;
            }
        }

        static void Main(string[] args)
        {
            //var c = new Creature();
            //WriteLine(c.Agility);
            //c.Agility = 20;
            //WriteLine(c.Agility);

            var si = new SampleImplicit();
            WriteLine(si);
            var si1 = new SampleImplicit("Override Text");
            WriteLine(si1);
            SampleImplicit si2 = "Amazing text";
            WriteLine(si2);
        }
    }
}
