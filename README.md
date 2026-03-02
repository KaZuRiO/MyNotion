# MyNotion

## Angular Architechture
```
src/
├── app/
│   ├── core/                # Singleton & logique globale
│   │   ├── services/
│   │   ├── guards/
│   │   ├── interceptors/
│   │   ├── models/
│   │   └── core.providers.ts
│   │
│   ├── shared/              # Réutilisable, sans logique métier
│   │   ├── components/
│   │   ├── directives/
│   │   ├── pipes/
│   │   └── ui/
│   │
│   ├── features/            # 💡 Cœur de l’application
│   │   ├── auth/
│   │   │   ├── pages/
│   │   │   ├── components/
│   │   │   ├── services/
│   │   │   ├── models/
│   │   │   ├── auth.routes.ts
│   │   │   └── auth.facade.ts
│   │   │
│   │   ├── dashboard/
│   │   └── user/
│   │
│   ├── app.routes.ts
│   └── app.component.ts
│
├── assets/
├── environments/
└── main.ts
```

## Getting Started

### Development

To start the entire environment (backend, frontend, postgres, adminer), run:

```bash
docker-compose up --build
```

- **Frontend:** [http://localhost:4200](http://localhost:4200)
- **Backend:** [http://localhost:5000](http://localhost:5000)
- **Swagger UI:** [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)
- **Adminer (Database GUI):** [http://localhost:8080](http://localhost:8080)
