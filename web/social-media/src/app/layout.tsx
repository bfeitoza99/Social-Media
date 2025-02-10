import { Toaster } from "react-hot-toast";
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
            <div className="flex w-full max-w-[1100px] border-l border-r border-neutral-800">
              <main className="w-full min-h-screen flex flex-col items-center justify-start gap-0">
                <Toaster position="top-right" reverseOrder={false} />
                {children}
              </main>
            </div>
          </div>
        </Providers>
      </body>
    </html>
  );
}
