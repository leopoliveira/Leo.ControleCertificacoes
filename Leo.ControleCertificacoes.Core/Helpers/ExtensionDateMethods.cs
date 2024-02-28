namespace Leo.ControleCertificacoes.Core.Helpers
{
    public static class ExtensionDateMethods
    {
        public static DateOnly FromDateTimeToDateOnly(this DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        public static DateTime FromDateOnlyToDateTime(this DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }
    }
}
