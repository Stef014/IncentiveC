## Instructions

Build a minimal ticket management system demonstrating clean architecture, data handling, and
pragmatic frontend decisions.

## Priorities

The backend functionality was prioritised over the frontend implementation to ensure that basic functionality is in place before the UI is rolled out.

This solution allows the capture of new tickets and the marking of tickets to open / closed on the frontend.

All backend functionality requested is in place.

## Trade-offs

I know the requirements asked to use SqlServer, but I really battled to get it to work on a Mac (even with Docker) and in the interest of time I continued with another db server. Changing to SqlServer should be trivial since entity EF Core is supported for both servers and the driver / connection string will need to be changed.

## Future Improvements

This solution does not implement basic security.

Authentication and the use of an API key could be introduced to enhance it in this regard.

Frontend features such as the capturing of comments could also be improved.

## Setup Instructions

### Backend

Navigate to the root directory:

```bash
cd ticketing-be
```

```bash
dotnet build
```

Navigate to the API directory:

```bash
cd src/Ticketing.Api
```

```bash
dotnet run
```

> Requires the .NET SDK to be installed.

### Frontend

Navigate to the frontend directory:

```bash
cd ticketing-fe/incentive-ticketing
```

```bash
npm install
```

```bash
npm run dev
```
