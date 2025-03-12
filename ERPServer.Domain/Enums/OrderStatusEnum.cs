using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Enums
{
    public sealed class OrderStatusEnum : SmartEnum<OrderStatusEnum>
    {
        public static readonly OrderStatusEnum Pending = new("Bekliyor", 1);
        public static readonly OrderStatusEnum RequirementsPlanDone = new("İhtiyaç Planı Çalışıldı", 1);
        public static readonly OrderStatusEnum Completed = new("Tamamlandı", 1);

        public OrderStatusEnum(string name, int value) : base(name, value)
        {
        }
    }
}
