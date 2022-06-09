using System.Collections.Generic;
using System.Linq;
using Test2.DTOs;
using Test2.Entities;

namespace  Test2.Extensions;

public static class DtoConversions
{
    public static IEnumerable<OrderDto> ConvertToDtos(this IEnumerable<ClientOrder> clientOrders)
    {
        if (clientOrders == null)
        {
            return null;
        }

        //     return (from order in clientOrders
        //         select new OrderDto
        //         {
        //             
        //             Ticker = company.Ticker,
        //             Name = company.Name,
        //             Location = company.Location,
        //             LogoUrl = GetLogoUrl(company),
        //             Equity = company.Equity,
        //             Description = company.Description
        //         }).ToList();
        // }
        //
        // public static CompanyDto ConvertToDto(this Company company)
        // {
        //     return new CompanyDto
        //     {
        //         Ticker = company.Ticker,
        //         Name = company.Name,
        //         Location = company.Location,
        //         LogoUrl = company.Branding.LogoUrl + $"?apiKey={ApiKey}"
        //     };
        // }
        return null;
    }

    public static IEnumerable<ConfectioneryDto> ConvertToDtos(this IEnumerable<Confectionery> confectioneries)
    {
     
        if (confectioneries == null)
        {
            return null;
        }

        return (from conf in confectioneries
            select new ConfectioneryDto
            {
                Name = conf.Name,
                PricePerOne = conf.PricePerOne
            }).ToList();
    }
}