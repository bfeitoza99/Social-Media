"use client";

import { useFilterPostStore } from "@/store/useFilterPostStore";
import { PostOrderBy } from "@/type/api/post";



const Filter = () => {
  const { orderBy, setOrderBy } = useFilterPostStore();

  return (
    <div className="flex border-b border-neutral-800 w-full">
      <button
        className={`flex-1 py-3 text-center text-white font-semibold ${
          orderBy === PostOrderBy.Latest ? "border-b-4 border-blue-500" : "text-gray-500"
        }`}
        onClick={() => setOrderBy(PostOrderBy.Latest)}
      >
        Latest
      </button>

      <button
        className={`flex-1 py-3 text-center text-white font-semibold ${
          orderBy === PostOrderBy.Trending ? "border-b-4 border-blue-500" : "text-gray-500"
        }`}
        onClick={() => setOrderBy(PostOrderBy.Trending)}
      >
        Trending
      </button>

      
    </div>
  );
};

export default Filter;
