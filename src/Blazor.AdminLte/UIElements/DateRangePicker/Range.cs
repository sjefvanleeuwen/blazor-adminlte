namespace Blazor.AdminLte
{
    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }

        public Range(T from, T to)
        {
            From = from;
            To = to;
        }
    }
}
