using Logic.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatFlow.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class DataController : ControllerBase
    {
        RoomLogic logic;

        public DataController(RoomLogic rlogic)
        {
            this.logic = rlogic;
        }

        [HttpGet]
        public void FillDatabase()
        {
            this.logic.GenerateData();
        }
    }
}
