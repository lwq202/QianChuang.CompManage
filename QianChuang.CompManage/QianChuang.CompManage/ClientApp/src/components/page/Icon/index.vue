<template>
  <span>
    <i :class="Icons"></i>
  </span>
</template>

<script lang='ts'>
import { Component, Vue, Prop } from "vue-property-decorator";
import fonts from "@/assets/font/font.ts";
/**
 * 图片 Icon
 */
@Component
export default class EditBox extends Vue {
    @Prop({ type: String, default: "" })
    icon;
    @Prop({ type: String, default: "" })
    iconFontClass;

    get Icons() {
      let iconClass = [this.icon];
      if (this.icon) {
          for (const item of fonts) {
            if (item.icons.includes(this.icon)) {
              iconClass.unshift(item.class);
              break;
            }
          }
      }
      if (this.iconFontClass) {
        iconClass.unshift(this.iconFontClass);
      }
      return iconClass;
    }
}
</script>
