﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Dtos.AddressDtos
{
    public class ResultAddressDto
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
