using System;

namespace XUnitTestProject.Models
{
    public struct DailyBet
    {
        public uint UserId;
        public DateTime Dt;
        public ulong TransactionId;
        public bool IsUsed;
    }
}