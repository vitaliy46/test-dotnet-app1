using System;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    public abstract class ReferenceRelease
    {
        protected ReferenceRelease(Type referenceType) { } 
        protected ReferenceRelease(DateTime releaseDate, Type referenceType)
        {
            ReleaseDate = releaseDate;
            ReferenceType = referenceType;
        }

        public DateTime ReleaseDate { get; set; }

        public Type ReferenceType { get; }
    }

    public class ReferenceRelease<TReferenceEntity> : ReferenceRelease where TReferenceEntity : ReferenceEntity
    {
        public ReferenceRelease() : base(typeof(TReferenceEntity)) { }
        public ReferenceRelease(DateTime releaseDate) : base(releaseDate, typeof(TReferenceEntity))
        { }
    }
}
