namespace TennisPlayers.Domain;

public sealed record PlayerDto(int Id,
                          string FirstName,
                          string LastName,
                          string ShortName,
                          string Sex,
                          CountryDto Country,
                          string Picture,
                          DataDto Data);

public sealed record CountryDto(string Picture,
                          string Code);

public sealed record DataDto(int Rank,
                          int points,
                          int Weight,
                          int Height,
                          int Age,
                          int[] Last);