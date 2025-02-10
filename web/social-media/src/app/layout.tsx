import "../styles/globals.css";
import { Providers } from "./providers";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="bg-black text-white">
        <Providers>
          <div className="flex justify-center">
            <div className="flex w-full max-w-[1100px] justify-center">
              <main className="flex-1 w-full md:max-w-[1000px] min-h-screen mx-4">
                {children}
              </main>

              <aside className="hidden lg:flex w-72 px-2 h-screen fixed right-0 top-0"></aside>
            </div>
          </div>
        </Providers>
      </body>
    </html>
  );
}
