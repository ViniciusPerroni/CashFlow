﻿using AutoMapper;
using CashFlow.Application.Identification.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.GetByEmailAndPassword
{
    public class UseCase : BaseUseCase<UserDto, Request, BaseResponse<UserDto>>, IUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UseCase(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        internal override async Task<BaseResponse<UserDto>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<UserDto>();
                var user = await userRepository.GetByEmail(request.Email);

                if (user == null)
                {
                    response.AddError("E-mail ou senha inválido.");
                    response.Data = null;
                    return response;
                }

                if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    response.AddError("E-mail ou senha inválido.");
                    response.Data = null;
                    return response;
                }

                response.Data = mapper.Map<UserDto>(user);
                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<UserDto>();
                response.AddError(ex.Message);

                response.Data = null;
                return response;
            }
        }
    }
}
