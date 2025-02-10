import { PostOrderBy } from "@/type/api/post";
import { create } from "zustand";

interface PostStoreState {
  orderBy: PostOrderBy;
  keyword: string;
  setOrderBy: (orderBy: PostOrderBy) => void;
  setKeyword: (keyword: string) => void;
}

export const useFilterPostStore = create<PostStoreState>((set) => ({
  orderBy: PostOrderBy.Latest, 
  keyword: "",
  setOrderBy: (orderBy) => set({ orderBy }),
  setKeyword: (keyword) => set({ keyword }),
}));