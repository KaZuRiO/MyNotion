import Image from "next/image";

export default function Home() {
  return (
    <div className="flex flex-col flex-1 items-center justify-center bg-zinc-50 font-sans dark:bg-black">
      <main className="flex flex-1 w-full max-w-3xl flex-col items-center justify-between py-32 px-16 bg-gray-100 dark:bg-black sm:items-start">
        <p>
          Lien vers la page de dashboard :{" "}
          <a href="/dashboard" className="text-blue-500">
            Dashboard
          </a>
        </p>
      </main>
    </div>
  );
}
