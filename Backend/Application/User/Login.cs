using System.Net.Mime;
using Application.Errors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
#pragma warning disable CS1591
    public class Login
    {
          public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string PassWord { get; set; }
            
        }
        public class QueryValidatar: AbstractValidator<Query>
        {
            public QueryValidatar()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.PassWord).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query,User>
        {
            private UserManager<User> _usermanager;
            private SignInManager<User> _signmanager;

            public Handler(UserManager<User> usermanager, SignInManager<User> signmanager)
            {
                _usermanager = usermanager;
                _signmanager = signmanager;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _usermanager.FindByEmailAsync(request.Email);
                if (user == null)
                    throw new RestException(HttpStatusCode.Unauthorized);
                var result = await _signmanager.CheckPasswordSignInAsync(user, request.PassWord, false);
                if (result.Succeeded)
                {
                    //Todo Generate Token

                    return new User{
                    Token = "this will be a token",
                    UserName = user.UserName,
                    Image = null,
                    };
                   
                }
                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }

    }
#pragma warning disable CS1591
}