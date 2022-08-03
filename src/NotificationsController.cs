using System;
using Microsoft.AspNetCore.Mvc;

namespace NST.Simple.Api
{
    [Route("api/[controller]")]
    public class SimpleController : ControllerBase
    {
        public SimpleController()
        {
        }

        [HttpGet("{a}/plus/{b}")]
        [ProducesDefaultResponseType]
        public int DoMath(int a, int b)
        {
            if (a > 10 && a < 100)
            {
                throw new Exception($"oups,  a value is {a}");
            }

            if (b > -90 && b < 70)
            {
                throw new Exception($"oups, b value is too be {b}");
            }

            return a + b;
        }

        [HttpGet("{a}/is/{b}")]
        [ProducesDefaultResponseType]
        public bool Compare(int a, int b)
        {
            return a == b;
        }

        [HttpGet("saved")]
        [ProducesDefaultResponseType]
        public int GetSaved([FromServices] SuperService superService)
        {
            return superService.GetSavedValue();
        }

        [HttpPut("saved")]
        [ProducesDefaultResponseType]
        public void Change([FromServices] SuperService superService)
        {
            superService.DoubleSavedValue();
        }
    }
}
