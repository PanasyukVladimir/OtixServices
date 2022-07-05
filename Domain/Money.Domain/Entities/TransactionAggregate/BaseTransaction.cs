using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    /// <summary>
    /// Абстрактиний клас транзакції
    /// </summary>
    public abstract class BaseTransaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Nodes { get; set; }
        public DateTime DateTime { get; set; }
        public int AccountProvideTransactionId { get; set; }
    }
}
