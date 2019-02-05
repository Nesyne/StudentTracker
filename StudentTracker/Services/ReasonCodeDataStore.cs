using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class ReasonCodeDataStore 
    {
        ObservableCollection<ReasonCode> _reasonCodes;

        public ReasonCodeDataStore()
        {
            _reasonCodes = new ObservableCollection<ReasonCode>();
            var mockItems = new ObservableCollection<ReasonCode>
            {
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Not following directions after 3 prompts"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Leaving assigned area"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Mild physical contact(rough houseing,touching)"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Serious physical contact (hitting, kicking,biting,etc)"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Disrupting class (yelling,misusing materials)"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Desctruction of property"},
                new ReasonCode { Id = Guid.NewGuid().ToString(), Name = "Self-harm(hitting,punching,etc)"}

            };

            foreach (var reason in mockItems)
            {
                _reasonCodes.Add(reason);
            }
        }

        public ObservableCollection<ReasonCode> GetReasonCodes()
        {
            return _reasonCodes;
        }
    }
}
