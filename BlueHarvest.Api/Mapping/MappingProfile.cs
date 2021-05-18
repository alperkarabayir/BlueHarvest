using AutoMapper;
using BlueHarvest.Api.Resources;
using BlueHarvest.Core.Models;

namespace BlueHarvest.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Customer, CustomerResource>();
            CreateMap<Account, AccountResource>();
            CreateMap<Transaction, TransactionResource>();

            // Resource to Domain
            CreateMap<CustomerResource, Customer>();
            CreateMap<AccountResource, Account>();
            CreateMap<TransactionResource, Transaction>();

            // Request Data
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveTransactionResource, Transaction>();
        }
    }
}
