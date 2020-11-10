using BlazorState;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public partial class SideBarState : State<SideBarState>
    {
        public string ActiveMenu { get; set; }

        public NavLinkState GetState(string item)
        {
            if (item == ActiveMenu)
                return NavLinkState.Active;
            else
                return NavLinkState.Inactive;
        }

        public override void Initialize()
        {
           
        }

        public class SelectMenuItemAction : IAction
        {
            public string Id { get; set; }
        }

        public class SelectMenuItemHandler : ActionHandler<SelectMenuItemAction>
        {
            public SelectMenuItemHandler(IStore aStore) : base(aStore) { }

            SideBarState State => Store.GetState<SideBarState>();
            public override Task<Unit> Handle(SelectMenuItemAction aAction, CancellationToken aCancellationToken)
            {
                State.ActiveMenu = aAction.Id;
                return Unit.Task;
            }
        }
    }
}
