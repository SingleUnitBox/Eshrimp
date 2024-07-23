using Eshrimp.Modules.Tanks.Domain.DomainEvents;
using Eshrimp.Modules.Tanks.Domain.Exceptions;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.Entities
{
    public class Tank : AggregateRoot
    {
        public Date SetUpDate { get; private set; }
        public IEnumerable<Shrimp> Shrimps => _shrimps;

        private List<Shrimp> _shrimps = new List<Shrimp>();

        internal Tank(AggregateId id)
        {
            Id = id;
        }

        public void ChangeSetUpDate(Date setUpDate, Date now)
        {
            if (setUpDate > now)
            {
                throw new InvalidSetUpDateException(setUpDate);
            }

            SetUpDate = setUpDate;
            AddEvent(new SetUpDateChanged(Id, SetUpDate));
        }

        public void AddShrimp(Shrimp shrimp, Date now)
        {
            var safeToAddDate = (Date)SetUpDate.Value.AddDays(30);
            if (safeToAddDate > now)
            {
                throw new CannotAddShrimpToUncycledTankException(safeToAddDate);
            }

            _shrimps.Add(shrimp);
            AddEvent(new ShrimpAdded(Id, shrimp.Id));
        }

        public static Tank Create(Guid id, DateTime setUpDate, DateTime now)
        {
            var tank = new Tank(id);
            tank.ChangeSetUpDate(setUpDate, now);

            return tank;
        }
    }
}
