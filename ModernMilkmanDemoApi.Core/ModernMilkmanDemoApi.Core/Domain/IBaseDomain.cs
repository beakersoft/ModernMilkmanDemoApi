using System;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public interface IBaseDomain
    {
        long Id { get; set; }
        DateTime CreatedUtc { get; set; }
        DateTime? UpdatedUtc { get; set; }
    }
}
