﻿using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class LocationService : ILocationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public LocationService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}