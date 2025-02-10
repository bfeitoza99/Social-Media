"use client";

import { useFilterPostStore } from "@/store/useFilterPostStore";



const Filter = () => {
  const { orderBy, setOrderBy } = useFilterPostStore();

  return (
    <div className="flex border-b border-neutral-800 w-full">
      <button
        className={`flex-1 py-3 text-center text-white font-semibold ${
          orderBy === "latest" ? "border-b-4 border-blue-500" : "text-gray-500"
        }`}
        onClick={() => setOrderBy("latest")}
      >
        Latest
      </button>

      <button
        className={`flex-1 py-3 text-center text-white font-semibold ${
          orderBy === "trending" ? "border-b-4 border-blue-500" : "text-gray-500"
        }`}
        onClick={() => setOrderBy("trending")}
      >
        Trending
      </button>

      
    </div>
  );
};

export default Filter;
