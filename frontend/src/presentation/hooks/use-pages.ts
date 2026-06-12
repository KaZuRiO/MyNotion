import { useState, useEffect } from "react";
import { Page } from "@/domain/entities/page";
import { GetPagesUseCase } from "@/application/use-cases/page/get-pages";
import { PageRepositoryImpl } from "@/infrastructure/repositories/page-repository.impl";

export function usePages() {
  const [pages, setPages] = useState<Page[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    const fetchPages = async () => {
      try {
        const repository = new PageRepositoryImpl();
        const useCase = new GetPagesUseCase(repository);
        const data = await useCase.execute();
        setPages(data);
      } catch (err) {
        setError(
          err instanceof Error ? err : new Error("Failed to fetch pages"),
        );
      } finally {
        setLoading(false);
      }
    };

    fetchPages();
  }, []);

  return { pages, loading, error };
}
