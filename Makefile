docker:
	docker compose down
	docker image prune --all --force
	docker volume prune --all --force
	docker compose up --build -d
	docker ps

docker-stop:
	docker compose down
	docker image prune --all --force
	docker volume prune --all --force
	docker ps

migrate:
	cd backend && dotnet ef migrations add InitialCreate \
		--project backend.Infrastructure/backend.Infrastructure.csproj \
		--startup-project backend.API/backend.API.csproj

migrate-stop:
	cd backend && rm -rf backend.Infrastructure/Migrations
