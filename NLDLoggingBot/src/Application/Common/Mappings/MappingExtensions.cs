﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(
        this IQueryable queryable,
        IConfigurationProvider configuration,
        CancellationToken cancellationToken)
        where TDestination
        : class
    {
        return queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync(cancellationToken);
    }
}
