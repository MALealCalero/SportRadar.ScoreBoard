# SportRadar.ScoreBoard

## Description

- Class library in C# .NET 6.0 which implements methods to support a basic scoreboard functionality. It includes testing project and sample console application, which uses the developed library and simulates the evolution during time of an example scoreboard.

## Methods implemented

- Start: Add a match to scoreboard, with initial score 0-0.
- Finish: Remove a match from scoreboard.
- Update: Update the score of a match.
- GetOrderedSummary: Return a collection ordered by addition of both scores (descending) and start date (descending).

## Assumptions

- Matches are added to scoreboard when it starts, and removes just after finish.
- Matches are saved in-memory, using a Dictionary<string, Match>. Key is the names of both teams, concatenated.
- Due to previous two points, matches can not be repeated on scoreboard.
- On update operation, it´s not necessary to validate that difference between argument score and saved score is more than one, to assume that errors can occur (connection issues, human errors,...). We just check that score is more than zero.

## Testing implemented

#### 1. Start: 
- 1.1. Match is added to collection.
- 1.2. Match starts with result 0-0.
- 1.3. Start date is filled.
- 1.4. Check if, when match already exists, throws an ArgumentException.

#### 2. Finish:
- 2.1. Match is removed from collection.
- 2.2. Check if, when match doesn´t exists, throws a KeyNotFoundException.

#### 3. Update:
- 3.1. Score is properly updated, for both teams.
- 3.2. Check if, when score updated is less than zero, throws an ArgumentException.
- 3.3. Check if, when match doesn´t exists, throws a KeyNotFoundException.

#### 4. GetOrderedSummary:
- 4.1. Check if collection result is expected one, with five matches between different and different scores and start dates.