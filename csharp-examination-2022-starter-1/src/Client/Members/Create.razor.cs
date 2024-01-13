using Microsoft.AspNetCore.Components;
using Shared.Members;
using System;
using System.Threading.Tasks;

namespace Client.Members
{
    public partial class Create
    {
        private MemberRequest.Create model { get; set; } = new();

        private Task CreateMemberAsync()
        {
            throw new NotImplementedException();
        }
    }
}
