using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    /// <summary>
    /// Abstract class for a transaction
    /// </summary>
    public abstract class BaseTransaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Nodes { get; set; }
        public DateTime Date { get; set; }
        public int AccountProvideTransactionId { get; set; }
    }
}
