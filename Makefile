docker:
	docker compose down
	docker image prune --all --force
	docker volume prune --all --force
	docker compose up --build -d
	docker ps

stop:
	docker compose down
	docker image prune --all --force
	docker volume prune --all --force
	docker ps