"use client";

import { Home } from "lucide-react";
import SidebarItem from "./sidebar-item";

const Sidebar = () => {
  const items = [
    {
      label: "Home",
      href: "/",
      icon: Home,
    },
  ];

  return (
    <div className="col-span-1 h-full pr-4 md:pr-6">
      <div className="flex flex-col items-end">
        <div className="space-y-2 lg:w-[230px]">             
          {items.map((item) => (
            <SidebarItem
              key={item.href}
              href={item.href}
              label={item.label}
              icon={item.icon}
            />
          ))}
        </div>
      </div>
    </div>
  );
};
export default Sidebar;
