using Marketplace.SaaS.Accelerator.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.SaaS.Accelerator.DataAccess.Context;
public partial class SaasKitContext
{

    /// <summary>
    /// カスタムマッピング: フォーク元のマッピングを上書き・追加する場合はここに記載する。
    /// 上書き理由や差分をコメントで明示すること。
    /// </summary>
    /// <remarks>
    /// 例:
    /// - ApplicationLog.LogDetail: Unicode対応のため IsUnicode(true) に変更
    /// - EmailTemplate.Subject: 日本語メール件名対応のため Unicode化
    /// </remarks>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        // フォーク元では .IsUnicode(false)（非Unicode）だが、日本語ログ対応のため Unicode に上書き
        // 例: EmailTemplateのSubject, TemplateBodyをUnicode対応に
        modelBuilder.Entity<Plans>(entity =>
        {
            entity.Property(e => e.DisplayName).IsUnicode(true);
        });

    }
}
