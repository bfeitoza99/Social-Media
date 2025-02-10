"use client";

import { useFilterPostStore } from "@/store/useFilterPostStore";
import { Search } from "lucide-react";

const SearchBar = () => {
  const { keyword, setKeyword } = useFilterPostStore();

  return (
    <div className="relative w-full max-w-md mr-auto  pt-2">
      <Search
        className="absolute left-4 top-1/2 transform -translate-y-1/2 text-gray-400"
        size={18}
      />
      <input
        type="text"
        placeholder="Search posts..."
        className="w-full pl-12 pr-4 py-2 bg-black text-white border border-gray-700 rounded-full outline-none focus:border-gray-500"
        value={keyword}
        onChange={(e) => setKeyword(e.target.value)}
      />
    </div>
  );
};

export default SearchBar;
