﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForAdmin
{
    public class TaskResponseModel
    {
        public int Id { get; set; }

        public string TaskDateOfBegin { get; set; }

        public string TaskDateOfEnd { get; set; }

        public string Description { get; set; }

        public bool IsActual { get; set; }

        public string Addresses { get; set; }
    }
}