using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Players.Command.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<bool>
    {   
        public string Name  { get; set; }
        public string TeamName  { get; set; }
        public int Games { get; set; }
        public decimal Points { get; set; }
        public decimal Assists { get; set; }
        public decimal Rebounds { get; set; }
        public decimal Steals { get; set; }
        public decimal Minutes { get; set; }
        public decimal Ftps { get; set; }
    }
}
