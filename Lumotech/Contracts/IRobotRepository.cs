﻿using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IRobotRepository
{
    Task<IEnumerable<Robot>> GetRobotsAsync(Guid robotStationId, RobotParameters robotParameters, bool trackChanges);
    Task<Robot> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges);
    void CreateRobotForRobotStation(Guid robotStationId, Robot robot);
    void DeleteRobot(Robot robot);
}