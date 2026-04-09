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
