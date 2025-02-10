import Sidebar from "@/components/layout/sidebar";
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
        <div className="flex justify-center">
          <div className="hidden md:flex fixed top-0 left-0 h-screen w-64 px-4">
            <Sidebar />
          </div>

          <div className="flex w-full max-w-[1200px]">
            <main className="flex-1 w-full md:w-[600px] min-h-screen">
              <Providers>{children}</Providers>
            </main>

            <aside className="hidden lg:flex w-80 px-4 h-screen fixed right-0 top-0"></aside>
          </div>
        </div>
      </body>
    </html>
  );
}
